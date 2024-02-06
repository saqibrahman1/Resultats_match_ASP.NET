const url = "/api/ButsAPI"; 
const connection = new signalR.HubConnectionBuilder().withUrl("/MatchHub").build();
connection.start()
    .catch(function (err) { return console.error(err.toString()) });

document.getElementById("savebtedit").addEventListener("click", function (event) {
    var id = document.getElementById("id").value;
    var temps = document.getElementById("temps").value;
    var joueurId = document.getElementById("joueurId").value;
    var matchId = document.getElementById("matchId").value;

    const but = {
        id: id,
        temps: temps,
        joueurId: joueurId,
        matchId: matchId
    };

    fetch( url + "/" + id,{
        method: "PUT",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(but)
    })
        .then(response => response.ok)
        .then(() => {
            connection.invoke("SendMessage").catch(function (err) {
                return console.error(err.toString());
            });
        })
        .catch(error => alert("Erreur API" + error));

    event.preventDefault();
});
