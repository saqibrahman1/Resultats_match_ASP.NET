const url = "/api/ButsAPI"; // Assurez-vous que l'URL correspond à votre API Buts
const connection = new signalR.HubConnectionBuilder().withUrl("/MatchHub").build();
connection.start()
    .catch(function (err) { return console.error(err.toString()); });

document.getElementById("createbtb").addEventListener("click", function (event) {
    var temps = document.getElementById("temps").value;
    var joueurId = document.getElementById("joueurid").value;
    var matchId = document.getElementById("matchid").value;

    const but = {
        id: 0,
        temps: temps,
        joueurId: joueurId,
        matchId: matchId
    };

    fetch(url, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(but)
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
