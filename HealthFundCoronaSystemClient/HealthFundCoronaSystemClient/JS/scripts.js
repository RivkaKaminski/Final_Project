// Function to fetch all members from the server
function fetchMembers() {
    fetch('http://localhost:5000/api/members')
        .then(response => response.json())
        .then(data => {
            const membersList = document.getElementById('members-list');
            membersList.innerHTML = '';
            data.forEach(member => {
                const li = document.createElement('li');
                li.textContent = `${member.firstName} ${member.lastName}`;
                li.addEventListener('click', () => fetchMemberDetails(member.id));
                membersList.appendChild(li);
            });
        })
        .catch(error => console.error('Error fetching members:', error));
}

// Function to handle login form submission
document.getElementById('login-form').addEventListener('submit', function (event) {
    event.preventDefault();
    const memberId = document.getElementById('member-id').value;
    // Call function to check if member exists
    if (memberExists(memberId)) {
        // Redirect to home page
        window.location.href = 'update-member.html';
    } else {
        // Redirect to registration page
        // If ID is not valid, navigate to create-member.html
        window.location.href = 'create-member.html';
    }
});
function isValidMemberId(memberId) {
    // Implement logic to check if the memberId exists in the system's database
    // For example, you can make an AJAX request to the server to validate the ID
    // For demonstration purposes, let's assume the ID is valid if it's a non-empty string
    return memberId.trim() !== '';
}

// Function to handle create member form submission
document.getElementById('create-member-form').addEventListener('submit', function (event) {
    event.preventDefault();
    // Collect member details from form fields
    const firstName = document.getElementById('first-name').value;
    const lastName = document.getElementById('last-name').value;
    const dateOfBirth = document.getElementById('date-of-birth').value;
    const dateOfApplication = document.getElementById('date-of-application').value; // New field
    const dateOfVaccination = document.getElementById('date-of-vaccination').value; // New field
    // Get other member details similarly

    // Call function to save member details to the database
    saveMemberDetails(firstName, lastName, dateOfBirth, dateOfApplication, dateOfVaccination); // Updated function call

});
function saveMemberDetails(firstName, lastName, dateOfBirth, dateOfApplication, dateOfVaccination) {
    // Implement logic to save member details to the database
    // This may involve making an AJAX request to the server
    // For demonstration purposes, let's log the member details to the console
    console.log('Saving member details:');
    console.log('First Name:', firstName);
    console.log('Last Name:', lastName);
    console.log('Date of Birth:', dateOfBirth);
    console.log('Date of Application:', dateOfApplication); // New field
    console.log('Date of Vaccination:', dateOfVaccination); // New field
    // Log other member details similarly
}// Function to handle update member form submission
document.getElementById('update-member-form').addEventListener('submit', function (event) {
    event.preventDefault();
    // Collect updated member details from form fields
    const updatedMemberDetails = {
        // Populate updated member details from form fields
    };
    // Call function to update member details
});

document.getElementById('photo-upload').addEventListener('change', function (event) {
    const reader = new FileReader();
    reader.onload = function () {
        const img = document.getElementById('selected-image');
        img.src = reader.result;
        img.style.display = 'block';
    };
    reader.readAsDataURL(event.target.files[0]);
});
// Function to fetch details of a specific member
function fetchMemberDetails(memberId) {
    fetch(`http://localhost:5000/api/members/${memberId}`)
        .then(response => response.json())
        .then(data => {
            const memberDetails = document.getElementById('member-details');
            memberDetails.innerHTML = `
                <p>ID: ${data.id}</p>
                <p>Name: ${data.firstName} ${data.lastName}</p>
                <p>Date of Birth: ${data.dateOfBirth}</p>
                <p>Date of Vaccination: ${data.dateOfVaccination}</p>
                <p>Date of Sickness: ${data.dateOfSickness}</p>
                <p>Date of Recovery: ${data.dateOfRecovery}</p>
            `;
        })
        .catch(error => console.error('Error fetching member details:', error));
}
function goBack() {
    window.history.forward();
}

// Initialize page
window.onload = fetchMembers;
