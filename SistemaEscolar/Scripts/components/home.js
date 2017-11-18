var Vue;
var axios;
var moment;
var app = new Vue({
    el: '#app-home',
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
        show: false,
        admision: {},
        nuevaAdmision: { AdmissionId: 0, UserId: 0, Date: new Date() },
        admisionModal: false,
        admisionEmpty: false,
        acta: [],
        foto: [],
        record: [],
        conducta: [],
        saldo: [],
        src: "http://localhost:51128/uploads/files/"
    },
    mounted: function () {
        var that = this;
        this.show = false;
        that.isLoading = true;
        that.getMyAdmission();
        that.nuevaAdmision.UserId = this.user.UserId;
        that.isLoading = false;
    },
    methods: {
        cerrarAdmision: function () {
            this.admisionModal = false;
            this.acta = [];
            this.foto = [];
            this.record = [];
            this.conducta = [];
            this.saldo = [];
        },
        getMyAdmission: function () {
            var that = this;
            axios.get('/api/Admission/GetMyAdmission/' + that.user.UserId)
                .then(function (response) {
                console.log(response);
                that.admision = response.data;
                if (that.admision.length == 0) {
                    that.admisionEmpty = true;
                }
                else {
                    that.admisionEmpty = false;
                }
                console.log(that.admisionEmpty);
            }).catch(function (error) {
            });
        },
        guardarAdmision: function () {
            var that = this;
            if (that.acta.length != 0 && that.foto.length != 0 && that.record.length != 0 && that.conducta.length != 0 && that.saldo.length != 0) {
                var data = new FormData();
                data.append("acta", that.acta[0]);
                data.append("foto", that.foto[0]);
                data.append("record", that.record[0]);
                data.append("conducta", that.conducta[0]);
                data.append("saldo", that.saldo[0]);
                console.log(data);
                axios.post('/api/Admission/' + that.user.UserId, data)
                    .then(function (response) {
                    console.log(response);
                    that.cerrarAdmision();
                    that.admisionEmpty = false;
                    that.$toast.open({
                        message: 'Admision solicitada',
                        type: 'is-primary'
                    });
                    that.getMyAdmission();
                }).catch(function (err) {
                    console.log(err);
                });
            }
            else {
                that.$toast.open({
                    message: 'Debe subir todos los archivos requeridos',
                    type: 'is-danger'
                });
            }
        }
    },
    filters: {
        dateFilter: function (fecha) {
            moment.locale('es');
            if (fecha == "" || fecha == null) {
                return "Fecha no disponible";
            }
            else {
                return moment(fecha).format('LL');
            }
        },
        statusFilter: function (value) {
            if (value == 1) {
                return "Solicitada";
            }
            else if (value == 2) {
                return "En Verificacion";
            }
            else if (value == 3) {
                return "Concluida";
            }
            else {
                return "Desconocido";
            }
        }
    }
});
//# sourceMappingURL=home.js.map