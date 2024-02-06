const url = "/api/MatchesAPI";
const connection = new signalR.HubConnectionBuilder().withUrl("/MatchHub").build();
connection.start()
    .catch(function (err) { return console.error(err.tostring()) })
document.getElementById("supprimerbtm").addEventListener("click", function (event) {
    var id = document.getElementById("id").value;
    fetch(url + "/"+id, {
        method:"DELETE",
        headers:{
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.ok)
        .then(() => {
            connection.invoke("SendMessage").catch(function (err) {
                return console.error(err.toString());
            });
        })
        .catch(error => alert("Erreur API Delete: " + error));
    event.preventDefault();
});