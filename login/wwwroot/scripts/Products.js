
let products = [];
let checkedCategories = [];
let cart = [];

const pageLoad = async () => {
     await getAllProducts();
     await getCategories();
     getLocalStoregeCart();

}
function getLocalStoregeCart() {
    let cartFromLocalStorege = JSON.parse(localStorage.getItem('cart')) || [];
    cart = cartFromLocalStorege;
    document.getElementById("ItemsCountText").innerText = cart.length;
    console.log("cartFromLocalStorege ", cartFromLocalStorege);
}

const getAllProducts = async () => {
    const response = await fetch(
       `/api/Product`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("products are not exists");
    }
    else {
        const data = await response.json();
        products = data;
        displayProducts(data);
    }
}
function addToCart(newProduct) {
    const index = cart.findIndex(product => product.id == newProduct.id)
    if (index < 0) {
        console.log(index);
        cart.push({ ...newProduct, 'count': 1 });
    }
    else {
        cart[index].count += 1;
    }
    document.getElementById("ItemsCountText").innerText = parseInt(document.getElementById("ItemsCountText").innerText) + 1;
    localStorage.setItem('cart', JSON.stringify(cart));
}

function displayProducts(data) {
    data.forEach(product => {
        var temp = document.getElementById("temp-card");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("h1").innerText = product.productName;
        clon.querySelector("img").src = `../pictures/${product.imagePath}`;
        clon.querySelector(".price").innerText = `${product.price} $`;
        clon.querySelector(".description").innerText = product.description;
        clon.querySelector("Button").addEventListener('click', (e) => {
            addToCart(product);
        });
        document.getElementById("PoductList").appendChild(clon);
    })
}
function displayCategories(data) {
    console.log("drawCategories");
    console.log(data);
    data.forEach(category => {
        var temp = document.getElementById("temp-category");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("input").id = category.categoryId;
        clon.querySelector("input").addEventListener('click', (e) => {
            search(e.target.id);
        });
        clon.querySelector("input").value = category.categoryName;
        clon.querySelector("label").for = category.categoryName;
        clon.querySelector(".OptionName").innerText = category.categoryName;
        clon.querySelector(".Count").innerText = (products.filter(product => product.categoryId == category.categoryId)).length;
        document.getElementById("categoryList").appendChild(clon);
    })
}
async function getCategories() {
    console.log("getCategories");
    const response = await fetch(
        `/api/Category`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("categories are not exists");
    }
    else {
        const data = await response.json();
        displayCategories(data);
    }
}






async function cleanPage() {
    console.log("cleanPage");
    document.getElementById("PoductList").innerHTML = '';

}

function TrackLinkID() {
    window.location.href = "update.html";
}
async function search(id) {
    console.log("id",id)
    if (id != null) {
        const ind = checkedCategories.findIndex(category => category == id);
        if (ind < 0) {
            checkedCategories.push(id);
        }
        else {
            checkedCategories = checkedCategories.filter(category => category != id);
        }
    }
    console.log(checkedCategories);
    cleanPage();
    checkedCategories = checkedCategories.filter(category => category != null);
    const productName = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;

    const categoriesUrl = checkedCategories.length > 0 ? `&categoryId=${checkedCategories.join("&categoryId=")}` : '';
    const response = await fetch(
        `/api/products/search?ProductName=${productName}&minPrice=${minPrice}&maxPrice=${maxPrice} ${categoriesUrl}`,
        {
            headers: {
                'Content-Type': 'application/json ; charest=utf-8'
            }
        }
    );
    if (!response.ok) {
        alert("products are not exists");
    }
    else {
        const data = await response.json();
        products = data;
        diaplay(data);
    }
}

document.addEventListener("load", pageLoad());

