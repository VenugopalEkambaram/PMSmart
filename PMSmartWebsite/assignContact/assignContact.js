angular.module('myApp').component('assignContact', {
	bindings: { projectId: '<', onSave: '&' },

	templateUrl: 'assignContact/assignContact.html',
	controller: function ($http) {
		var ctrl = this;
		ctrl.addMode = false;

		ctrl.setMode = function () {
			ctrl.addMode = true;
			$http.get('http://localhost:49956/api/contact?projectId=' + ctrl.projectId)
				.then(function (response) {
					ctrl.contactsForAssignation = response.data;
				})
				.catch(function (response) {
					alert('Oops! Sorry! Something went wrong. Please contact administrator.', response.status, response.data);
				});
		};

		ctrl.resetMode = function () {
			$http.put('http://localhost:49956/api/contact/', {
				'contactId': ctrl.contact.contactId,
				'firstName': ctrl.contact.firstName,
				'lastName': ctrl.contact.lastName,
				'projectId': ctrl.projectId
			})
				.then(function (response) {
					ctrl.onSave();
					ctrl.addMode = false;
				})
				.catch(function (response) {
					alert('Oops! Sorry! Something went wrong. Please contact administrator.', response.status, response.data);
				});

		};

	}

});