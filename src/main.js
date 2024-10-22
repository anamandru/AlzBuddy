function setFormMessage(formElement, type, message) {
    const messageElement = formElement.querySelector(".form__message");

    messageElement.textContent = message;
    messageElement.classList.remove("form__message--success", "form__message--error");
    messageElement.classList.add(`form__message--${type}`);
}


// function setInputError(inputElement, message){
//     inputElement.classList.add("form__input--error");
//     inputElement.parentElement.querySelector(".form__input-error-message").textContent = message;
// }

function ValidateEmail(input) {
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (input.value.match(validRegex)) {
      alert("Valid email address!");
      document.form1.text1.focus();
      return true;
    } else {
      alert("Invalid email address!");
      document.form1.text1.focus();
      return false;
    }
  }


document.addEventListener("DOMContentLoaded", () =>{
    const loginForm = document.querySelector("#email-form02-1k");
    const createAccountForm = document.querySelector("#createAccount");
    
    // document.querySelector("#linkCreateAccount").addEventListener("click", e => {
    //     e.preventDefault();
    //     loginForm.classList.add("form--hidden");
    //     createAccountForm.classList.remove("form--hidden");

    // });

    // document.querySelector("#linkLogin").addEventListener("click", e => {
    //     e.preventDefault();
    //     loginForm.classList.remove("form--hidden");
    //     createAccountForm.classList.add("form--hidden");
    // });

    loginForm.addEventListener("submit", e =>{
        e.preventDefault();
        //Login fetch etc
        setFormMessage(loginForm, "eror", "Invalid username & password combination");
    });


    document.querySelectorAll(".form__input").forEach(inputElement =>{

      inputElement.addEventListener("blur", e =>{
        if (e.target.id === "signupUsername" && e.target.value.length > 0 && e.target.value.length < 10) {
            setInputError(inputElement, "Username must be at least 10 characters");
        }
        
        if (e.target.id ==="email" && !validateEmail(e.target.value)) {
            setInputError(inputElement, "Please enter a valid email address");
            allFieldsCompleted = false;
        }
        const passwordInput = createAccountForm.querySelector("#signupPassword");
        const confirmPasswordInput = createAccountForm.querySelector("#confirmPassword");

        if (passwordInput.value !== confirmPasswordInput.value) {
            setInputError(confirmPasswordInput, "Passwords do not match");
            allFieldsCompleted = false;
        }
        
      }) ; 
 

     createAccountForm.addEventListener("submit", e => {
      e.preventDefault();
      
      //clearAllInputErrors(createAccountForm);

      function validateEmail(email) {
        // Use a regular expression for basic email validation
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    
    //   const passwordInput = createAccountForm.querySelector("#signupPassword");
    //   const confirmPasswordInput = createAccountForm.querySelector("#confirmPassword");

    //   if (e.target.id ==="signupPassword" && e.target.value !== e.target.value) {
    //       setInputError(confirmPasswordInput, "Passwords do not match");
    //   } else {
    //       // Clear any existing errors for confirmPasswordInput
    //       clearInputError(confirmPasswordInput);

    //       // Additional validation or form submission logic for createAccountForm
    //   }
      


    });
            

      inputElement.addEventListener("input", e => {
        clearInputError(inputElement);
        });
    });
});
