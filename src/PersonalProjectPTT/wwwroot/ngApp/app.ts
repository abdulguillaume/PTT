namespace PersonalProjectPTT {

    angular.module('PersonalProjectPTT', ['ui.router', 'ngResource', 'ui.bootstrap', 'ngMaterial','ngMessages']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: PersonalProjectPTT.Controllers.HomeController,
                controllerAs: 'controller'
            })
            //.state('secret', {
            //    url: '/secret',
            //    templateUrl: '/ngApp/views/secret.html',
            //    controller: PersonalProjectPTT.Controllers.SecretController,
            //    controllerAs: 'controller'
            //})
            .state('clients', {
                url: '/clients',
                templateUrl: '/ngApp/views/registered/clientList.html',
                controller: PersonalProjectPTT.Controllers.ClientListController,
                controllerAs: 'controller'
            })
            //.state('addClient', {
            //    url: '/addClient',
            //    templateUrl: '/ngApp/views/registered/addClient.html',
            //    controller: PersonalProjectPTT.Controllers.AddClientController,
            //    controllerAs: 'controller'
            //})
            .state('projects', {
                url: '/projects',
                templateUrl: '/ngApp/views/registered/projectList.html',
                controller: PersonalProjectPTT.Controllers.ProjectListController,
                controllerAs: 'controller'
            })
            //.state('addProject', {
            //    url: '/addProject',
            //    templateUrl: '/ngApp/views/registered/addProject.html',
            //    controller: PersonalProjectPTT.Controllers.AddProjectController,
            //    controllerAs: 'controller'
            //})
            //.state('editProject', {
            //    url: '/editProject/:id',
            //    templateUrl: '/ngApp/views/registered/editProject.html',
            //    controller: PersonalProjectPTT.Controllers.EditProjectController,
            //    controllerAs: 'controller'
            //})
            .state('projectDetails', {
                url: '/project/:id',
                templateUrl: '/ngApp/views/registered/projectDetails.html',
                controller: PersonalProjectPTT.Controllers.AboutProjectController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: PersonalProjectPTT.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: PersonalProjectPTT.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            //.state('externalRegister', {
            //    url: '/externalRegister',
            //    templateUrl: '/ngApp/views/externalRegister.html',
            //    controller: PersonalProjectPTT.Controllers.ExternalRegisterController,
            //    controllerAs: 'controller'
            //}) 
            //.state('about', {
            //    url: '/about',
            //    templateUrl: '/ngApp/views/about.html',
            //    controller: PersonalProjectPTT.Controllers.AboutController,
            //    controllerAs: 'controller'
            //})
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('PersonalProjectPTT').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('PersonalProjectPTT').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
