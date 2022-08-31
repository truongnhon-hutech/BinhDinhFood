//preloading for page
$(window).on('load', function () { // makes sure the whole site is loaded
    var status = $('#status');
    var preloader = $('#preloader');
    var body = $('body');
    status.fadeOut(); // will first fade out the loading animation
    preloader.delay(0).fadeOut('fast'); // will fade out the white DIV that covers the website.
    body.delay(0).css({ 'overflow': 'visible' });
    var vidDefer = document.getElementsByTagName('iframe');
    for (var i = 0; i < vidDefer.length; i++) {
        if (vidDefer[i].getAttribute('data-src')) {
            vidDefer[i].setAttribute('src', vidDefer[i].getAttribute('data-src'));
        }
    }
})