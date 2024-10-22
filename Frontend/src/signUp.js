function submitForm() {
document.getElementById('linkCreateAccount').addEventListener('click', function() {
      // Collect data from input fields
      var name = document.getElementById('name-form02-1k').value;
      var email = document.getElementById('email-form02-1k').value;
      var phone = document.getElementById('phone-form02-1k').value;
      var password = document.getElementById('signupPassword-form02-1k').value;
      var confirmPassword = document.getElementById('confirmPassword-form02-1k').value;

      // Validate data (you may add more validation as needed)
      if (!name || !email || !phone || !password || !confirmPassword) {
          alert('Please fill in all fields.');
          return;
      }

      if (password !== confirmPassword) {
          alert('Password and Confirm Password must match.');
          return;
      }

      // Create a JSON object with the collected data
      var formData = {
          id:0,
          name: name,
          email: email,
          password: password,
          phoneNumber: phone
         
      };

      // Send data to the API
      fetch('https://localhost:7008/api/User/AddUser', {
          method: 'POST',
          headers: {
              'Content-Type': 'application/json',
          },
          body: JSON.stringify(formData),
      })
      .then(response => {
          if (!response.ok) {
              throw new Error('Network response was not ok');
          }
          return response.json();
      })
      .then(async result => {
          console.log('Success:', result);
          //alert('Account created successfully!');
          window.location.href = 'index.html';
      })
      .catch(error => {
          // Handle error response from the API
          console.error('Error:', error);
          //alert('Error creating account. Please try again.');
      });
});
}
