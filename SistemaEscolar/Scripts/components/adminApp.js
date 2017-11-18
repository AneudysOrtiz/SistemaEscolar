var app = new Vue({

    el:'#app-admin',
    data:{
        mensaje:'Hola',
        activeTab:'Dashboard',
        user:JSON.parse(sessionStorage.getItem('user')),
        usersQuantity:0
    },
    mounted:function(){
var that=this;
        axios.get('/api/Users/getUsersQuantity')
            .then(function (response){
                console.log(response)
                that.usersQuantity=response.data;
            }).catch(function (error){
                console.log(error)
            })

    }

})