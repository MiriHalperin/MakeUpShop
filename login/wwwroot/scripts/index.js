

//register to api
async function Register() {
    console.log("hi I came to register")
    const userName = document.getElementById("userNameReg").value;
    const password = document.getElementById("userPasswordReg").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;


    const response = await fetch(`https://localhost:44351/api/Users/register`, {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ "Email": userName, "FirstName": firstName, "LastName": lastName, "Password": password })

    })
    if (response.ok) {
        console.log(response.status)
        const newUser = await response.json();
        localStorage.setItem('user', JSON.stringify(newUser));
      
    }
    else { alert('request failed'); }
}

async function Login() {

    const userName = document.getElementById("userNameLogin").value;
    const userPassword = document.getElementById("userPasswordLogin").value;
    const ans = await fetch(`https://localhost:44351/api/users/Login`, {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ "Email": userName, "Password": userPassword })

    })
    console.log(ans)
}


async function Update() {

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const id = JSON.parse(localStorage.getItem('user')).id;

    const ans = await fetch(`https://localhost:44351/api/users/${id}`, {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ "Id": id, "Email": email, "Password": password, "FirstName": firstName, "LastName": lastName })

    })
    DealWithUpdateAns(ans);
}

async function DealWithRegisterAns(ans) {

    if (ans.status == 204)
        alert("user name already exist ");

    else if (ans.status == 200) {
        alert("user addded");
    }
    else {
        const ansJson = await ans.json();
        if (ansJson.errors) {
            if (ansJson.errors.Email)
                alert("Email not valid");
            if (ansJson.errors.Password)
                alert("password length must be between 5-20");
        }
    }
}


async function LoadUserDetails() {

    const user = JSON.parse(localStorage.getItem('user'));
    document.getElementById("email").setAttribute('value', user.email);
    document.getElementById("password").setAttribute('value', user.password);
    document.getElementById("firstName").setAttribute('value', user.firstName);
    document.getElementById("lastName").setAttribute('value', user.lastName);
    const text = `hello ${user.firstName} ${user.lastName}`
    document.getElementById("hello").innerHTML = text;

}

async function passwordStrength(e) {
    //const password1 = e.target.value;
    const password = document.getElementById("userPasswordReg").value;
    console.log(password);

    const res = await fetch(`https://localhost:44351/api/password`, {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)

    })

    const strength = await res.json();
    document.getElementById("file").setAttribute("value", strength);
}

