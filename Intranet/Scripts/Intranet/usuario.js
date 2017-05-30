function Usuario() {

    var self = this;

    self.Id = ko.observable();
    self.PessoaId = ko.observable();
    self.PerfilId = ko.observable();
    self.Login = ko.observable();
    self.Administrador = ko.observable();
    self.Ativo = ko.observable();

    self.Permissoes = ko.observableArray();

    var Usuario =
    {
        Id: self.Id,
        PessoaId: self.PessoaId,
        PerfilId: self.PerfilId,
        Login: self.Login,
        Administrador: self.Administrador,
        Ativo: self.Ativo
    };

    $.ajax({
        type: "Get",
        url: "/Usuario/Obter/1", //passar para a controller o id do usuário logado
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            self.Permissoes(data.Permissoes);
        },
        error: function (error) {
            alert(error.status + " - " + error.statusText);
        }
    });
}