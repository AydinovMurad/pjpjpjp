document.addEventListener('DOMContentLoaded', function() {
    const buttons = document.querySelectorAll('.select-btn');
    const overlay = document.querySelector('.overlay');
    const modal = document.querySelector('.modal_product');

    buttons.forEach(button => {
        button.addEventListener('click', function() {
            modal.classList.remove('hidden');
            overlay.classList.remove('hidden');
            modal.style.display = 'block';
            overlay.style.display = 'block';
        });
    });

    overlay.addEventListener('click', function() {
        modal.classList.add('hidden');
        overlay.classList.add('hidden');
        modal.style.display = 'none';
        overlay.style.display = 'none';
    });
});
const minusButtons = document.querySelectorAll("#minus");
    const plusButtons = document.querySelectorAll("#plus");

    minusButtons.forEach(button => {
        button.addEventListener("click", function() {
            const span = this.nextElementSibling;
            let value = parseInt(span.textContent);
            if (value > 0) {
                value--;
                span.textContent = value;
            }
        });
    });

    plusButtons.forEach(button => {
        button.addEventListener("click", function() {
            const span = this.previousElementSibling;
            let value = parseInt(span.textContent);
            value++;
            span.textContent = value;
        });
    });



    document.addEventListener("DOMContentLoaded", function() {
        const signInLink = document.getElementById("signin");
        const signUpLink = document.getElementById("signup");
        const basketIcon = document.getElementById("basket");
      
        const modalSignIn = document.querySelector(".modal");
        const modalSignUp = document.querySelector(".modal_1");
        const modalBasket = document.querySelector(".modal_busket");
      
        const overlays = document.querySelectorAll(".overlay");
        const closeButtons = document.querySelectorAll(".close-btn, .closebtn");
      
        function openModal(modal) {
            modal.classList.remove("hidden");
            modal.previousElementSibling.classList.remove("hidden"); // Show overlay
        }
      
        function closeModal() {
            modalSignIn.classList.add("hidden");
            modalSignUp.classList.add("hidden");
            modalBasket.classList.add("hidden");
            overlays.forEach(overlay => overlay.classList.add("hidden"));
        }
      
        signInLink.addEventListener("click", function(event) {
            event.preventDefault();
            openModal(modalSignIn);
        });
      
        signUpLink.addEventListener("click", function(event) {
            event.preventDefault();
            openModal(modalSignUp);
        });
      
        basketIcon.addEventListener("click", function(event) {
            event.preventDefault();
            openModal(modalBasket);
        });
      
        closeButtons.forEach(button => button.addEventListener("click", closeModal));
        overlays.forEach(overlay => overlay.addEventListener("click", closeModal));
      });
      //--------------
      function toggleLanguageMenu() {
        const menu = document.getElementById('language-menu');
        menu.style.display = menu.style.display === 'block' ? 'none' : 'block';
      }
      
      function selectLanguage(language, flagSrc) {
        const countryName = document.getElementById('countryname');
        const countryFlag = document.getElementById('country');
        
        countryName.textContent = language;
        countryFlag.src = flagSrc;
      
        const menu = document.getElementById('language-menu');
        menu.style.display = 'none';
      }
      
      // Закрытие меню при клике вне его
      document.addEventListener('click', function(event) {
        const languageContainer = document.querySelector('.language');
        const menu = document.getElementById('language-menu');
        if (!languageContainer.contains(event.target)) {
            menu.style.display = 'none';
        }
      });