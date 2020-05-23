var connection = new signalR.HubConnectionBuilder()
    .withUrl("/dashboardHub")
    .build();

connection.on("CadastroUsuarioEvent", (message) => {

    $("#tblUsuario").append(
        `<tr>
            <td>${message.nomeUsuario}</td>
        </tr>`
    );
    
});

connection.start();