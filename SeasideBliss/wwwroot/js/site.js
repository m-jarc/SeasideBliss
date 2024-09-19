// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// testimonials.js

// Wait for the DOM to load
// testimonials.js

document.addEventListener('DOMContentLoaded', function () {
    const testimonials = document.querySelector('.testimonial-container');
    const testimonialItems = document.querySelectorAll('.testimonial');
    let index = 0;

    // Function to rotate testimonials
    function rotateTestimonials() {
        const testimonialWidth = testimonials.offsetWidth;
        index++;

        // Reset index if it exceeds the number of testimonials
        if (index >= testimonialItems.length) {
            index = 0;
        }

        // Translate container to show the next testimonial
        const offset = -index * testimonialWidth;
        testimonials.style.transform = `translateX(${offset}px)`;
    }

    // Rotate testimonials every 5 seconds (5000ms)
    setInterval(rotateTestimonials, 5000);

    // Adjust the container width on window resize
    window.addEventListener('resize', () => {
        const testimonialWidth = testimonials.offsetWidth;
        const offset = -index * testimonialWidth;
        testimonials.style.transform = `translateX(${offset}px)`;
    });
});

