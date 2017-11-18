var Vue;
var axios;
var app = new Vue({
    el: '#app-admin',
    data: {
        mensaje: 'Hola',
        activeTab: 'Dashboard',
        user: JSON.parse(sessionStorage.getItem('user')),
        users: [],
        usersQuantity: 0,
        isLoading: false,
        usuario: { 'Name': null, 'LastName': null, 'Email': null, 'Rol': null, 'Telefono': null, 'Sexo': null, 'Direccion': null },
        registrarUsuarioModal: false,
        tmpFiles: [],
        show: false
    },
    mounted: function () {
        var that = this;
        this.show = false;
        that.isLoading = true;
        axios.get('/api/Users/getUsersQuantity')
            .then(function (response) {
            console.log(response);
            that.usersQuantity = response.data;
        }).catch(function (error) {
            console.log(error);
        });
        axios.get('/api/Users')
            .then(function (response) {
            console.log(response);
            that.users = response.data;
        }).catch(function (error) {
            console.log(error);
        });
        that.isLoading = false;
    },
    methods: {
        cerrarAdminModal: function () {
            this.registrarUsuarioModal = false;
            this.usuario = { 'Name': null, 'LastName': null, 'Email': null, 'Rol': null, 'Telefono': null, 'Sexo': null, 'Direccion': null };
        },
        guardarUsuario: function () {
            var that = this;
            this.isLoading = true;
            console.log(this.usuario);
            axios.post('/api/Users', this.usuario)
                .then(function (response) {
                var model = {
                    Email: that.usuario.Email,
                    Password: that.usuario.Email,
                    ConfirmPassword: that.usuario.Email
                };
                axios.post('/api/Account/NewUser', model)
                    .then(function (response) {
                    console.log(response);
                }).catch(function (error) {
                    console.log(error);
                });
                that.users.push(that.usuario);
                that.cerrarAdminModal();
                that.isLoading = false;
                that.$toast.open({
                    message: 'Usuario creado con exito',
                    type: 'is-info'
                });
                that.usersQuantity++;
            }).catch(function (error) {
                this.isLoading = true;
                console.log(error);
            });
        }
    }
});
//# sourceMappingURL=admin.js.map