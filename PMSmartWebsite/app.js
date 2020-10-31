var myApp = angular.module('myApp', ['ui.router']);

myApp.config(function ($stateProvider) {
  var homeState = {
    name: 'home',
    url: '/',
    template: '<window-pane title="Projects"></window-pane>'
  }

  var assignationState = {
    name: 'assignation',
    url: '/assignation',
    template: '<assignation-grid></assignation-grid>'
  }

  var projectsState = {
    name: 'projects',
    url: '/projects',
    template: '<window-pane title="Projects"></window-pane>'
  }

  var contactsState = {
    name: 'contacts',
    url: '/contacts',
    template: '<window-pane title="Contacts"></window-pane>'
  }

  $stateProvider.state(homeState);
  $stateProvider.state(projectsState);
  $stateProvider.state(contactsState);
  $stateProvider.state(assignationState);
})