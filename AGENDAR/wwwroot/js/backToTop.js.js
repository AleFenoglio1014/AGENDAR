var botonTop = document.getElementById('top1');

window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 200 || document.documentElement.scrollTop > 200) {
        botonTop.style.display = "block";
    } else {
        botonTop.style.display = "none";
    }
}

function top1() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}