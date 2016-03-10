var model = {
    createNotepad: function (name) {
        if (!name) {
            return;
        }

        var p = $.ajax({
            url: '/api/notepad/create',
            type: 'POST',
            data: {
                NotepadName: name
            }
        });

        p.success(function () {
            
        });

        p.error(function (error) {
            debugger;
        });
    }
}

function init() {
    ko.applyBindings(new viewModel());
}

function viewModel() {
    this.newNotepadName = ko.observable();
    this.createNotepad = function () {
        model.createNotepad(this.newNotepadName());
    }
}