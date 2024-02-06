const url = "/api/MatchesAPI"; 
let $matches = $("#matches");

getMatches();

function getMatches() {
    fetch(url)
        .then(response => response.json())
        .then(data => {
            data.forEach(match => {
                let template = `
                    <tr> 
                        <td>${match.dateHeure}</td>
                        <td>${match.scoreDomicile}</td>
                        <td>${match.scoreExterieur}</td>
                        <td>${match.equipeDomicile.nom}</td> 
                        <td>${match.equipeExterieur.nom}</td>
                        
                        <td>
                            <a href="/Matches/Edit?id=${match.id}">Modifier</a> |
                            <a href="/Matches/Details?id=${match.id}">Détails</a> |
                            <a href="/Matches/Delete?id=${match.id}">Supprimer</a>
                        </td>
                    </tr>`;
                $matches.append($(template));
            });
        })
        .catch(error => alert("Erreur API"));
}

const connection = new signalR.HubConnectionBuilder().withUrl("/MatchHub").build();

connection.start()
    .catch(function (err) { return console.error(err.toString()); });

connection.on("MatchChange", function () {
    $matches.empty();
    getMatches();
});
