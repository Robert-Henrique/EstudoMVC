/*
 * Namespace para o View Model
 */
if (typeof (ss) === "undefined")
    var ss = {};

/*
 * Início da classe Perfil
 */
ss.Perfil = function () {
    var self = this;

    self.Id = ko.observable();
    self.PerfilId = ko.observable();
    self.Nome = ko.observable();
    self.Ativo = ko.observable();
    self.IES = ko.observable();

    self.ListarPerfis = ko.observable();
    self.ListarPermissoes = ko.observableArray();

    self.init();

};

ss.Perfil.prototype.init = function () {
    var self = this;

    portal.ajax({
        url: actionURL("ListarPerfis", "Perfil", "SS"),
        dataType: "json",
        async: false,
        success: function (result) {
            self.ListarPerfis(result);
        }
    });
};

ss.Perfil.prototype.preencher = function (perfil) {
    var self = this;

    self.Id(perfil.Id)
    self.PerfilId(perfil.PerfilId)
    self.Nome(perfil.Nome)
    self.Ativo(perfil.Ativo)
    self.IES(perfil.IES)

    self.ListarPermissoes(perfil.ListarPermissoes)

};

ss.Perfil.prototype.limpar = function () {
    var self = this;

    self.Id(null)
    self.PerfilId(null)
    self.Nome(null)
    self.Ativo(null)
    self.IES(null)

    self.ListarPermissoes.removeAll();
    self.ListarPerfis.removeAll();

};

ss.Perfil.prototype.obter = function (id) {
    var self = this;

    if (id == null) {
        self.limpar();
        return;
    }

    portal.ajax({
        url: actionURL("Obter", "Perfil", "SS"),
        data: { "id": id },
        dataType: "json",
        success: function (result) {
            self.preencher(result);
        }
    });
};

ss.Perfil.prototype.salvar = function () {
    var self = this;

    portal.ajax({
        url: actionURL("Salvar", "Perfil", "SS"),
        data: ko.toJSON(self),
        dataType: "json",
        contentType: "application/json, charset=utf-8",
        success: function (result) {
            var cadastro = self.Id() == null || self.Id() == 0;
            self.Id(result);
            if (cadastro) {
                self.obter(self.Id());
                portal.confirm("Perfil salvo com sucesso.<br>Selecione abaixo as Permissões do Perfil criado.", null, [{ label: "Ok", className: "btn-success" }]);
            } else
                portal.confirm("Perfil salvo com sucesso.", null, [{ label: "Ok", className: "btn-success", callback: function () { self.voltar(); } }]);
        }
    }, self);
};

function excluir(model, item) {
    portal.confirm("Deseja excluir este Perfil?", null, [{
        label: "Sim", className: "btn-danger", callback: function () {
            portal.ajax({
                url: actionURL("Excluir", "Perfil", "SS"),
                data: { "id": item.Id },
                dataType: "json",
                success: function () {
                    model.filtrar(model.pageNumber());
                    portal.confirm("Perfil excluído com sucesso.", { title: "Atenção" }, [{ label: "Ok", className: "btn-success", callback: null }]);
                }
            });
        }
    }, { label: "Não" }]);
}

ss.Perfil.prototype.voltar = function () {
    var self = this;

    window.location = actionURL("Perfil", "SS");
};
function voltar() {
    window.location = actionURL("", "SS");
}

function salvarPermissoes(id, perfilId) {
    var chk = document.getElementById("chk-" + id);

    portal.ajax({
        url: actionURL("SalvarPermissao", "Perfil", "SS"),
        data: { "permissaoId": id, "perfilId": perfilId, "isChecked": chk.checked },
        dataType: "json",
        success: function () {
            model.obter(perfilId);
        }
    });
}

/*
 * Final da classe Perfil
 */
