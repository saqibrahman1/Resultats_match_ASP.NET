const url = "/api/MatchesAPI"; // Assurez-vous que l'URL correspond à votre API Matches
const connection = new signalR.HubConnectionBuilder().withUrl("/MatchHub").build();
connection.start()
    .catch(function (err) { return console.error(err.toString()); });

document.getElementById("createbtm").addEventListener("click", function (event) {
    var dateHeure = document.getElementById("dateheure").value;
    var scoreDomicile = document.getElementById("scoredomicile").value;
    var scoreExterieur = document.getElementById("scoreexterieur").value;
    var equipeDomicileId = document.getElementById("equipedomicileid").value;
    var equipeExterieurId = document.getElementById("equipeexterieurid").value;

    const match = {
        id: 0,
        dateHeure: dateHeure,
        scoreDomicile: scoreDomicile,
        scoreExterieur: scoreExterieur,
        equipeDomicileId: equipeDomicileId,
        equipeExterieurId: equipeExterieurId
    };

    fetch(url, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(match)
    })
        .then(response => response.json())
        .then(() => {
            connection.invoke("SendMessage").catch(function (err) {
                return console.error(err.toString());
            });
        })
        .catch(error => alert("Erreur API"));

    event.preventDefault();
});
