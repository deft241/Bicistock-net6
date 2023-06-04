// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const spinnerWrapper = document.querySelector('.spinner-wrapper');

window.addEventListener('load', () => {
    spinnerWrapper.style.opacity = '0';

    setTimeout(() => {
        spinnerWrapper.style.display = 'none';
    }, 1000)

})
