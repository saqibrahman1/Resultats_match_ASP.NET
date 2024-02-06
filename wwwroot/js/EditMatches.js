const url = "/api/MatchesAPI"; // URL de votre API Matches
const connection = new signalR.HubConnectionBuilder().withUrl("/MatchHub").build(); 
connection.start()
    .catch(function (err) { return console.error(err.toString()); });

document.getElementById("savebtm").addEventListener("click", function (event) {
    var id = document.getElementById("id").value;
    var dateHeure = document.getElementById("dateHeure").value;
    var scoreDomicile = document.getElementById("scoreDomicile").value;
    var scoreExterieur = document.getElementById("scoreExterieur").value;
    var equipeDomicile = document.getElementById("equipeDomicile").value;
    var equipeExterieur = document.getElementById("equipeExterieur").value;

    const match = {
        id: id,
        dateHeure: dateHeure,
        scoreDomicile: scoreDomicile,
        scoreExterieur: scoreExterieur,
        equipeDomicileId: equipeDomicile, 
        equipeExterieurId: equipeExterieur
    };

    fetch(url + "/" + id, {
        method: "PUT",
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
