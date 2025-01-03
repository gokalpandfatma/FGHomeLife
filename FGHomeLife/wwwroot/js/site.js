// Navbar Scroll Effect
window.addEventListener('scroll', function () {
    if (window.scrollY > 50) {
        document.querySelector('.navbar').classList.add('scrolled');
    } else {
        document.querySelector('.navbar').classList.remove('scrolled');
    }
});

// Scroll to Top Button
window.addEventListener('scroll', function () {
    if (window.scrollY > 200) {
        document.querySelector('.scroll-top').classList.add('visible');
    } else {
        document.querySelector('.scroll-top').classList.remove('visible');
    }
});

document.querySelector('.scroll-top').addEventListener('click', function () {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
});

// Page Loading Animation
window.addEventListener('load', function () {
    const loader = document.querySelector('.loading-overlay');
    if (loader) {
        loader.style.opacity = '0';
        setTimeout(() => {
            loader.style.display = 'none';
        }, 500);
    }
});