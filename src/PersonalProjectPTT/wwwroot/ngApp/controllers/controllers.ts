namespace PersonalProjectPTT.Controllers {

    class _Project
    {
        public id: number;
        public name: string;
    }

    class _Task {
        public id: number;
        public title: string;
    }


    export class HomeController {
        public message = "Welcome!";
    }


    export class AboutController {
        public message = "Hello from the about page!";
    }

    export class ClientListController {
        public message = `Below are registered clients.`;
        public clients;

        public deleteClient(id: number) {

            debugger;

            if (!this.accountService.getClaim('IsAdmin')) {

                let msg = `Operation not allowed. ${this.accountService.getUserName()} is not an admin!`;

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/alertDialog.html',
                    controller: 'DialogAlertController',
                    controllerAs: 'modal',
                    size: 'sm',
                    resolve: {
                        msg: () => msg
                    }
                });

            } else {

                debugger;

                this.$http.delete(`/api/client/` + id).then(() => {
                    this.$state.reload();
                })
            }

            
        }

        public modalAddClient()
        {
            let that = this;

            this.$uibModal.open({
                templateUrl: '/ngApp/views/registered/addClientDialog.html',
                controller: 'DialogAddClientController',
                controllerAs: 'modal',
                size: 'sm'
            })
                .result
                .then(function () {
                    that.$state.reload();
                });
        }


        public modalEditClient(obj: any) {
            let that = this;
            debugger;
            this.$uibModal.open({
                templateUrl: '/ngApp/views/registered/editClientDialog.html',
                controller: 'DialogEditClientController',
                controllerAs: 'modal',
                size: 'sm',
                resolve: {
                    clientToEdit: () => obj
                }
            })
                .result
                .then(function () {
                    that.$state.reload();
                });
        }


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $uibModal: angular.ui.bootstrap.IModalService, private accountService: PersonalProjectPTT.Services.AccountService) {
            $http.get(`/api/client`).then((response) => {
                this.clients = response.data;
            });

        }
    }

    export class DialogAlertController {

        public ok(){
            this.$uibModalInstance.close();
        }

        constructor(private msg:string, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {

            debugger;
        }
    }

    export class DialogAddClientController {

        public clientToAdd;

        public types = ["individual", "group", "organization"];

        public ok() {

            let user = this.accountService.getUserName();

            if (user == null)
                user = "God";

            this.clientToAdd.createBy = user;

            this.$http.post(`/api/client`, this.clientToAdd).then((response) => {
                this.$uibModalInstance.close();
            })
        }

        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProjectPTT.Services.AccountService) {

        }
    }

    export class DialogEditClientController {

        public types = ["individual", "group", "organization"];

        public ok() {

            this.$http.post(`/api/client`, this.clientToEdit).then((response) => {
                this.$uibModalInstance.close();
            })
        }

        constructor(private clientToEdit: any, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProjectPTT.Services.AccountService) {
            debugger;
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

        public modalAddProject()
        {
            let that = this;

            this.$uibModal.open({
                templateUrl: '/ngApp/views/registered/projectAddDialog.html',
                controller: 'DialogAddProjectController',
                controllerAs: 'modal',
                size: 'lg'
            })
                .result
                .then(function () {
                    that.$state.reload();
                });
        }


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $uibModal: angular.ui.bootstrap.IModalService) {
            $http.get(`/api/project`).then((response) => {
                this.projects = response.data;
            });

        }
    }

    export class DialogAddProjectController {

        public projectToAdd;

        public priorities = ["urgent", "high", "medium", "low"];

        public clients;

        public ok() {

            let user = this.accountService.getUserName();

            if (user == null)
                user = "God";

            this.projectToAdd.manager = user;

            this.projectToAdd.status = "created";

            debugger;

            this.$http.post(`/api/project`, this.projectToAdd).then((response) => {

                this.$uibModalInstance.close();
            });

        }

        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProjectPTT.Services.AccountService) {

            $http.get(`/api/client`).then((response) => {
                this.clients = response.data;
            });

        }
    }

    export class DialogEditProjectController {

        public priorities = ["urgent", "high", "medium", "low"];

        public statuses = [ "ongoing", "completed", "pending", "cancelled"];

        public clients;

        public ok() {

            this.$http.post(`/api/project`, this.projectToEdit).then((response) => {
                //this.$state.go(`projectDetails`,{id: this.projectToEdit.id});
                this.$uibModalInstance.close();
            });

        }

        constructor(private projectToEdit: any, private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance
        ) {

            $http.get(`/api/project/` + this.projectToEdit.id ).then((response) => {
                this.projectToEdit = response.data;
            });


            $http.get(`/api/client`).then((response) => {
                this.clients = response.data;
            });

        }
    }

    export class AboutProjectController {

        public project;


        public modalEditProject(obj: any)
        {
            debugger;

            if (this.accountService.getUserName() != this.project.manager) {

                debugger;

                let msg = "You cannot modify this project. You are not the Project Manager!";

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/alertDialog.html',
                    controller: 'DialogAlertController',
                    controllerAs: 'modal',
                    size: 'sm',
                    resolve: {
                        msg: () => msg
                    }
                });

            } else {

                let that = this;

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/projectEditDialog.html',
                    controller: 'DialogEditProjectController',
                    controllerAs: 'modal',
                    resolve: {
                        projectToEdit: () => obj
                    },
                    size: 'lg'
                })
                    .result
                    .then(function () {
                        that.$state.reload();
                    });

            }
        }

        public modalAddTask(obj: _Project)
        {

            debugger;

            if (!this.accountService.getClaim('IsAdmin') && this.accountService.getUserName() != this.project.manager) {


                debugger;

                let msg = "You cannot add task to this project. You are not the Project Manager!";

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/alertDialog.html',
                    controller: 'DialogAlertController',
                    controllerAs: 'modal',
                    size: 'sm',
                    resolve: {
                        msg: () => msg
                    }
                });

            } else {

                debugger;

                let that = this;

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/taskAddDialog.html',
                    controller: 'DialogAddTaskController',
                    controllerAs: 'modal',
                    resolve: {
                        _project: () => obj
                    },
                    size: 'lg'
                })
                    .result
                    .then(function () {
                        that.$state.reload();
                    });
            }
        }

        public modalEditTask(projectName: string, obj: _Task) {

            debugger;

            if (!this.accountService.getClaim('IsAdmin') && this.accountService.getUserName() != this.project.manager) {

                debugger;

                let msg = "You cannot add task to this project. You are not the Project Manager!";

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/alertDialog.html',
                    controller: 'DialogAlertController',
                    controllerAs: 'modal',
                    size: 'sm',
                    resolve: {
                        msg: () => msg
                    }
                });

            } else {

                let that = this;

                debugger;

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/taskEditDialog.html',
                    controller: 'DialogEditTaskController',
                    controllerAs: 'modal',
                    resolve: {
                        projectName: () => projectName,
                        task: () => obj
                    },
                    size: 'lg'
                })
                    .result
                    .then(function () {
                        that.$state.reload();
                    });
            }
        }


        public modalDeleteTask(id: number) {

            debugger;

            if (!this.accountService.getClaim('IsAdmin') && this.accountService.getUserName() != this.project.manager) {

                debugger;

                let msg = `You cannot delete this task. ${this.accountService.getUserName()} is not an admin, nor the project manager of this project!`;

                this.$uibModal.open({
                    templateUrl: '/ngApp/views/registered/alertDialog.html',
                    controller: 'DialogAlertController',
                    controllerAs: 'modal',
                    size: 'sm',
                    resolve: {
                        msg: () => msg
                    }
                });

            } else {

                debugger;

                this.$http.delete(`/api/task/` + id).then(() => {
                    this.$state.reload();
                })
            }


        }

        public modalAddComment(obj: _Task) {
            let that = this;

            debugger;

            this.$uibModal.open({
                templateUrl: '/ngApp/views/registered/commentDialog.html',
                controller: 'DialogCommentController',
                controllerAs: 'modal',
                resolve: {
                    _task: () => obj
                },
                size: 'md'
            })
                .result
                .then(function () {
                    that.$state.reload();
                });
        }


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private $uibModal: angular.ui.bootstrap.IModalService, private accountService: PersonalProjectPTT.Services.AccountService) {

            let projectId = $stateParams[`id`];

            $http.get(`/api/project/` + projectId).then((response) => {
                this.project = response.data;
            });
        }
    }


    export class DialogAddTaskController {

        public task;

        public employees;

        public priorities = ["urgent", "high", "medium", "low"];

        public ok() {

            debugger;

            this.task.status = "created";

            this.$http.post(`/api/task`, { projectId: this._project.id, task: this.task }).then((response) => {
                this.$uibModalInstance.close();
            })
        }

        constructor(private _project: _Project, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

            $http.get(`/api/employee`).then((response) => {
                this.employees = response.data;
            });
        }
    }


    export class DialogEditTaskController {

        public employees;

        public priorities = ["urgent", "high", "medium", "low"];

        public statuses = ["ongoing", "completed", "pending", "cancelled"];

        public ok() {

            debugger;

            this.$http.post(`/api/task`, { projectId: 0, task: this.task }).then((response) => {
                this.$uibModalInstance.close();
            })
        }

        constructor(private projectName: string, private task: _Task, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

            $http.get(`/api/employee`).then((response) => {
                this.employees = response.data;
            });

        }
    }

    export class DialogCommentController {

        public comment;//comment object
        public commentsStr:string;
        public commentsJson; //comment json

        public ok() {

            this.comment.author = this.accountService.getUserName();

            this.$http.post(`/api/comment`, { taskId: this._task.id, comment: this.comment }).then((response) => {
                this.$uibModalInstance.close();
            })
        }

        constructor( private _task: _Task, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService, private $state: ng.ui.IStateService, private accountService: PersonalProjectPTT.Services.AccountService) {

            $http.get(`/api/comment/` + _task.id).then((response) => {

                this.commentsJson = response.data;

                this.commentsStr = '';


                debugger;

                for (let c of this.commentsJson)
                {
                    this.commentsStr = this.commentsStr + 'Text: ' + c.text + ', author: ' + c.author + ', Date: ' + c.createDate + '\n-----\n';
                }

                debugger;
            });

        }
    }


    angular.module('PersonalProjectPTT').controller('DialogAlertController', DialogAlertController);

    angular.module('PersonalProjectPTT').controller('DialogAddClientController', DialogAddClientController);
    angular.module('PersonalProjectPTT').controller('DialogEditClientController', DialogEditClientController);
    angular.module('PersonalProjectPTT').controller('DialogAddProjectController', DialogAddProjectController);
    angular.module('PersonalProjectPTT').controller('DialogEditProjectController', DialogEditProjectController);
    angular.module('PersonalProjectPTT').controller('DialogAddTaskController', DialogAddTaskController);
    angular.module('PersonalProjectPTT').controller('DialogEditTaskController', DialogEditTaskController);
    angular.module('PersonalProjectPTT').controller('DialogCommentController', DialogCommentController);


    angular.module('PersonalProjectPTT').config(['$qProvider', function ($qProvider) {
        $qProvider.errorOnUnhandledRejections(false);
    }]);


}
