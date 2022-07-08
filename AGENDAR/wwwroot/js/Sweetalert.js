const selectHeader = document.querySelector('#header');
if (selectHeader) {
    document.addEventListener('scroll', () => {
        window.scrollY > 300 ? selectHeader.classList.add('sticked') : selectHeader.classList.remove('sticked');
    });
}

/**
 * Mobile nav toggle
 */
const mobileNavShow = document.querySelector('.mobile-nav-show');
const mobileNavHide = document.querySelector('.mobile-nav-hide');

document.querySelectorAll('.mobile-nav-toggle').forEach(el => {
    el.addEventListener('click', function (event) {
        event.preventDefault();
        mobileNavToogle();
    })
});

function mobileNavToogle() {
    document.querySelector('body').classList.toggle('mobile-nav-active');
    mobileNavShow.classList.toggle('d-none');
    mobileNavHide.classList.toggle('d-none');
}