// Best Practice: Use a Namespace to organize your code
var MyScripts = window.MyScripts || {};

MyScripts.ContactForm = {

    // 1. Function to run when the Form Loads
    onLoad: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var alertStrings = {
            confirmButtonLabel: "OK",
            text: "Hello From Erez Amsalem Web Developer :-)",
            title: "Welcome"
        };
        var alertOptions = { height: 120, width: 260 };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    },

    // 2. Function to run when First Name or Last Name changes
    onNameChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var alertStrings = {
            confirmButtonLabel: "OK",
            text: "Name Changed Successfully",
            title: "Notification"
        };
        var alertOptions = { height: 120, width: 260 };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    },

    // 3. UPDATED: Email Change with Auto-Save
    onEmailChange: function (executionContext) {
        var formContext = executionContext.getFormContext();
        var email = formContext.getAttribute("emailaddress1").getValue();

        if (email != null) {
            console.log("Email changed to: " + email);

            var alertStrings = {
                confirmButtonLabel: "OK",
                text: "Email updated successfully. Saving record...",
                title: "Notification"
            };
            var alertOptions = { height: 120, width: 260 };

            // Open Alert -> Wait for OK -> Save
            Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
                function (success) {
                    formContext.data.entity.save();
                }
            );
        }
    },

    // 4. Function: Auto-save when Telephone Number changes
    onPhoneChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var alertStrings = {
            confirmButtonLabel: "OK",
            text: "Telephone Number Changed Successfully. Saving now...",
            title: "Notification"
        };
        var alertOptions = { height: 120, width: 260 };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
            function (success) {
                formContext.data.entity.save();
            }
        );
    },

    // 5. Function: Pop up AND Auto-Save when Job Title changes
    onJobTitleChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var alertStrings = {
            confirmButtonLabel: "OK",
            text: "Job title added successfully. Saving record...",
            title: "Notification"
        };
        var alertOptions = { height: 120, width: 260 };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
            function (success) {
                formContext.data.entity.save();
            }
        );
    }
};