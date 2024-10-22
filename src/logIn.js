function submitForm2() {
     document.getElementById('logInButton').addEventListener('click', function() {
          // Collect data from input fields
          var email = document.getElementById('email-form02-6').value;
          var password = document.getElementById('password').value;
    
          // Validate data (you may add more validation as needed)
          if (!email || !password ) {
              alert('Please fill in all fields.');
              return;
          }
    
          // Create a JSON object with the collected data
          var formData = {
              email: email
          };
    
          // Send data to the API
          fetch('https://localhost:7008/api/User/GetByEmail?email='+email, {
              method: 'GET',
              headers: {
                  'Content-Type': 'application/json',
              },
          })
          .then(response => {
              if (!response.ok) {
                  throw new Error('Network response was not ok');
              }
              return response.json();
          })
          .then(async result => {
            var userId=result.id;
            window.location.href = 'dashboard.html?id=' + userId;
          })
          .catch(error => {
              // Handle error response from the API
              console.error('Error:', error);
              alert('Invalid email or password. Please try again.');
          });
    });
    
    }
    