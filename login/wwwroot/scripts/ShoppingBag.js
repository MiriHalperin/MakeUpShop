
let cart = [];

function orderSum() {
    let sum = 0;
    cart.forEach(product => sum += product.price*product.count);
    return sum;
}


async function placeOrder() {
    console.log("placeOrder");
    const orderItems = cart.map(product => { return ({ productId: product.id, quantity: product.count }) });
    const order = JSON.stringify({ UserId: parseInt(JSON.parse(localStorage.getItem("userInfo")).id), OrderSum: orderSum(), Date: new Date().toISOString().slice(0,10), OrderItems: orderItems });
    console.log(order);
    if (cart) {
        const response = await fetch(
            '/api/orders', {
            method: 'POST',
            body: order,
            headers: {
                'Content-Type': 'application/json'
            }
        }
        );
        if (response.status == 201) {
            localStorage.removeItem('cart');
            cart = [];
            const data = await response.json();
            document.getElementsByTagName("tbody")[0].innerHTML = '';
            let h_3 = document.createElement("h3");
            h_3.innerHTML = `Order ${data.id} added successfully`;
            document.getElementsByTagName("tbody")[0].appendChild(h_3);
            drawCartDetails();
        }
        else {
            alert("oppss...");
        }
    }
}


function deleteItem(productId) {
    console.log("deleteItem");
    const ind = cart.findIndex(p => p.id == productId);
    if (cart[ind].count > 1) {
        cart[ind].count--;
    }
    else {
        cart = cart.filter(product => product.id != productId);
    }
    localStorage.setItem('cart', JSON.stringify(cart));
    drawOrderProducts();
}


function getLocalStorageCart() {
    let cartFromLocalStorage = JSON.parse(localStorage.getItem('cart')) || [];
    cart = cartFromLocalStorage;
    console.log("cartFromLocalStorage ", cartFromLocalStorage);
}

function drawCartDetails() {
    let count = 0;
    cart.forEach(product => count += product.count);
    document.getElementById("itemCount").innerText = count;
    document.getElementById("totalAmount").innerText = "$"+orderSum();
}

function drawOrderProducts() {
    console.log("drawOrderProducts");
    document.getElementsByTagName("tbody")[0].innerHTML = ''
    cart.map(product => {
        var temp = document.getElementById("temp-row");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("img").src = `../pictures${product.img}`;
        clon.querySelector(".descriptionColumn h3").innerText = product.name; 
        clon.querySelector(".itemNumber").innerText = product.count;
        clon.querySelector(".price").innerText = `${product.price * product.count} $`;
        clon.querySelector(".expandoHeight").addEventListener('click', () => {
            deleteItem(product.id);
        });
        document.getElementsByTagName("tbody")[0].appendChild(clon);
    })
    drawCartDetails();
}



function atLoad() {
    getLocalStorageCart();
    drawOrderProducts();
}

/*document.addEventListener("load", atLoad());*/
window.onload = () => { atLoad() };
