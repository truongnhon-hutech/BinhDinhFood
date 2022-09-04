var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/customerCount").build();
var adminConnection = new signalR.HubConnectionBuilder().withUrl("/hubs/adminHub").build();
connection.on('updateCustomerCounter', (count) => {

    var page = document.getElementById('customerCount');
    page.innerText = count;
})
// Connect successfully and send a signal to admin
function fulfilled() {
    console.log("Connected succesfully!");
    adminConnection.start()
}
 //Connection failed to start
function rejected() {
    console.log("Failed to connect");
}


connection.start().then(fulfilled, rejected)

// 4/9/2022