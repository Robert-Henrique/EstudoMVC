function Area() {

    var self = this;

    self.Id = ko.observable();
    self.Nome = ko.observable();
    self.Ativo = ko.observable();

    self.Areas = ko.observableArray();

    var Area =
    {
        Id: self.Id,
        Nome: self.Nome,
        Ativo: self.Ativo
    };
    
    $.ajax({
        type: "Get",
        url: "/Area/Obter",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            self.Areas(data);
        },
        error: function (error) {
            alert(error.status + " - " + error.statusText);
        }
    });

    self.salvar = function (Area) {
        $.ajax({
            url: "/Area/Salvar",
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Area),
            success: function (data) {
                if (data != null) {
                    //bootbox.alert("Área salvo com sucesso.", function () {
                    //    self.voltar();
                    //});
                } else {
                    //bootbox.alert("Erro ao salvar a Área.", function () { });
                }
            }
        });
    };

    self.obter = function (Id) {
        $.ajax({
            url: "/Area/Obter",
            cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: { id: Id },
            dataType: "json",
            success: function (data) {
                if ($.isEmptyObject(Id)) {
                    self.Areas(data);
                } else {
                    self.Area(data);
                }
            }
        });
    };

    self.deletar = function (Id) {
        bootbox.confirm("Tem certeza que deseja excluir?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Area/Excluir",
                    cache: false,
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    data: { id: Id },
                    dataType: "json",
                    success: function (data) {
                        self.Areas.remove(data);
                        self.obter(null);
                    }
                }).fail(
                        function (hxr, textoStatus, err) {
                            alert(err);
                        }
                    );
            }
        });
    };

    self.voltar = function () {
        var url = window.location.protocol + '//' + window.location.host + '/Area/Index';
        window.location = url;
    };
}