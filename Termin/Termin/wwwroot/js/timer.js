// Set the date we're counting down to
var countDownDate;
//have to add action when expired

var connection = new signalR.HubConnectionBuilder().withUrl("/timerHub").build();
connection.start().then(function () {
    var url = window.location.href + "&handler=Time";
    console.log(url);
    $.get(url).done(function (data) {
        console.log(data.studenEnd);
        countDownDate = new Date(data.studenEnd).getTime();
    })
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("RevieveTimer", function (time) {
    console.log(time);
    countDownDate = new Date(time).getTime();
})


// Update the count down every 1 second
var x = setInterval(function () {

    // Get today's date and time
    var now = new Date().getTime();

    // Find the distance between now and the count down date
    var distance = countDownDate - now;

    // Time calculations for days, hours, minutes and seconds
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // Output the result in an element with id="demo"
    document.getElementById("demo").innerHTML = hours + "h "
        + minutes + "m " + seconds + "s ";

    // If the count down is over, write some text 
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("demo").innerHTML = "EXPIRED";
    }
}, 1000);
