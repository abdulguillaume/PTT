namespace PersonalProjectPTT.Controllers {

    class _Project
    {
        public id: number;
        public name: string;
    }

    export class HomeController {
        public message = "Hello from the home page!";
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get("/api/secrets").then((results) => {
                this.secrets = results.data;
                debugger;
            });
        }
    }


    export class AboutController {
        public message = "Hello from the about page!";
    }

    export class AddClientController {

        public clients;

        public clientToAdd;

        public types = ["individual", "group", "organization"];

        public addClientRqst() {

            let user = this.accountService.getUserName();

            if (user == null)
                user = "God";

            this.clientToAdd.createBy = user;

            this.$http.post(`/api/client`, this.clientToAdd).then((response) => {
                this.$state.go(`clients`);
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProjectPTT.Services.AccountService) {


            $http.get(`/api/client`).then((response) => {
                this.clients = response.data;
            })

        }
    }

    export class ClientListController {
        public message = `Below are our registered clients.`;
        public clients;

        public deleteClient(id: number) {
            this.$http.delete(`/api/client/` + id).then(() => {
                this.$state.reload();
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get(`/api/client`).then((response) => {
                this.clients = response.data;
            });

        }
    }

    export class ProjectListController {
        public message = "Project list.";

        public projects;

        public statuses = [
            {
                "name": "created", "btn": "btn-primary"
            },
            {
                "name": "ongoing", "btn": "btn-info"
            },
            {
                "name": "completed", "btn": "btn-success"
            },
            {
                "name": "pending", "btn": "btn-warning"
            },
            {
                "name": "cancelled", "btn": "btn-danger"
            },
            {
                "name": "All", "btn": "btn-default"
            }
        ];


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get(`/api/project`).then((response) => {
                this.projects = response.data;
                debugger;
            });

        }
    }


    export class AddProjectController {

        public projects;

        public projectToAdd;

        public priorities = ["urgent", "high", "medium", "low"];

        //public statuses = ["created", "ongoing", "completed", "pending", "cancelled"];

        public clients;

        public addProjectRqst() {

            let user = this.accountService.getUserName();

            if (user == null)
                user = "God";

            this.projectToAdd.manager = user;

            this.projectToAdd.status = "created";

            //to remove later
            //this.projectToAdd.startDate = new Date();
            //this.projectToAdd.endDate = this.projectToAdd.startDate;

            debugger;

            this.$http.post(`/api/project`, this.projectToAdd).then((response) => {
                this.$state.go(`projects`);
            });


        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProjectPTT.Services.AccountService
        ) {

            $http.get(`/api/project`).then((response) => {
                this.projects = response.data;
            });

            $http.get(`/api/client`).then((response) => {
                this.clients = response.data;
            });

        }
    }

    export class AboutProjectController {

        public project;


        public showModal(obj: _Project)
        {
            let that = this;


            debugger;

            this.$uibModal.open({
                templateUrl: '/ngApp/views/registered/taskDialog.html',
                controller: 'DialogController',
                controllerAs: 'modal',
                resolve: {
                    _project: () => obj
                },
                size: 'sm'
            })
                .result
                .then(function () {
                    that.$state.reload();
                });
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private $uibModal: angular.ui.bootstrap.IModalService) {

            let projectId = $stateParams[`id`];

            $http.get(`/api/project/` + projectId).then((response) => {
                this.project = response.data;
            })
        }
    }

    export class DialogController {

        public task;

        public project;

        public ok() {

            debugger;

            this.$http.post(`/api/task`, { projectId: this._project.id, task: this.task }).then((response) => {
                //this.$state.go(`clients`);
                //this.task.projectId = this._project.id; //not needed
                debugger;
                this.$uibModalInstance.close();
            })
        }

        constructor(private _project: _Project, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            //this.task.projectId = _project.id;
        }
    }

    angular.module('PersonalProjectPTT').controller('DialogController', DialogController);


}
