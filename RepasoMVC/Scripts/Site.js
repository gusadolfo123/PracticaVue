
var app = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue!',
        categorias: [],
        loading: false
    },
    beforeCreate: function () {
        loading = true;
    },
    created: function () {
        loading = false;
    },
    methods: {
        listarCategorias: async function () {
            this.loading = true;
            await fetch('Categories/Lista')
                .then(response => {
                    return response.json();                
                })
                .then(data => {
                    setTimeout(() => {
                        this.categorias = data;
                        this.loading = false;
                    }, 2000);                     
                })
                .catch(response => {
                    console.log(response);
                }); 
        },
        guardarCategoria: async function () {
            
            var url = 'Categories/CreateCategory';
            var data = { CategoryID: 0, Description: "Prueba", Products: null };

            await fetch(url, {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data) // data can be `string` or {object}!
                })
                .then(res => {
                    return res.json();
                })
                .catch(error => console.log('Error:', error))
                .then(response => {
                    this.categorias.push({
                        CategoryID: response.category.CategoryID,
                        Description: response.category.Description,
                        Products: null
                    });
                    console.log('Success:', response);
                });
        },
        editarCategoria: function (id) {
            console.log(id);
        },
        detalleCategoria: function (id) {
            console.log(id);
        },
        eliminarCategoria: function (id) {
            console.log(id);
        }
    }
});




