var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/adminHub").build();

connection.on('updateCustomerCounter', (count) => {
    var page = document.getElementById('customerCount');
    page.innerText = count;
});

function fulfilled() {
    console.log("Connected succesfully!");
}

function rejected() {
    console.log("Failed to connect");
}

connection.start().then(fulfilled, rejected)

// 4/9/2022