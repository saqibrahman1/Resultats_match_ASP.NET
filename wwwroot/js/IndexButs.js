const url = "/api/ButsAPI"; // 
let $buts = $("#buts");
getButs();
    
function getButs() {
    fetch(url)
        .then(response => response.json())
        .then(data => {
            data.forEach(but => {
                let template = `<tr>
                                    <td>${but.temps}</td>
                                    <td>${but.joueur ? `${but.joueur.prenom} ${but.joueur.nom}` : ''}</td>
                                   <td>${but.match.equipeExterieur.nom} </td>
                                    <td>
                                        <a href="/Buts/Edit?id=${but.id}">Edit</a> |
                                        <a href="/Buts/Details?id=${but.id}">Details</a> |
                                        <a href="/Buts/Delete?id=${but.id}">Delete</a>
                                    </td>
                                </tr>`;
                $buts.append($(template));
            });
        })
        .catch(error => alert("Erreur API"));
}

const connection = new signalR.HubConnectionBuilder().withUrl("/MatchHub").build();
connection.start()
    .catch(function (err) { return console.error(err.toString()); });

connection.on("MatchChange", function () {
    $buts.empty();
    getButs();
});
