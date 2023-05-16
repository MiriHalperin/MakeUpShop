

const user = JSON.parse(localStorage.getItem("userInfo"));

const name = async () => {
    console.log("In func");
    let m_body = document.getElementsByTagName("body")[0];
    let h_3 = document.createElement("h3");
    h_3.innerHTML = `Hello ${user.firstName} ${user.lastName}`;
    m_body.appendChild(h_3);
}

name();

async function Update() {
    const email = document.getElementById("registEmail").value;
    const password = document.getElementById("registPassword").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const userToSend = JSON.stringify({ password: password, email: email, firstName: firstName, lastName: lastName, id: user.id });
    const response = await fetch(
        `https://localhost:44390/api/users/${user.id}`, {
        method: 'PUT',
        body: userToSend,
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("the eupdate faild");
    }
    else {
        const data = await response.json();
        localStorage.setItem("userInfo", JSON.stringify({ firstName: data.firstName, lastName: data.lastName, id: data.id });
        alert("the update was successful");
    }
}
