var model = {
    createNotepad: function (name) {
        if (!name) {
            return;
        }

        $.post('/api/notepad/create', { NotepadName: name }).success(function () {
            /* Возможно не стоит вызывать из модели сторонние функции */
            updateNotepads();
        });
    },

    getNotepads: function () {
        return $.get('/api/notepad/getNotepads');
    },

    getNotepadContent: function (name) {
        return $.get('/api/notepad/getNotepadContent/' + name);
    },

    updateNotepad: function (name, content) {
        $.post('/api/notepad/update', {
            NotepadName: name,
            Content: content
        }).success(function () {
            alert('Обновление прошло успешно!');
        });
    },

    selectNotepad: function (notepadName) {
        $('.selected').removeClass('selected');
        $('.notepad-i[name="' + notepadName + '"]').addClass('selected');
    }
}

var viewModel = new ViewModel();

function init() {
    ko.applyBindings(viewModel);
    updateNotepads();
}

function updateNotepads() {
    model.getNotepads().success(function (data) {
        viewModel.notepads(data);
    });
}

function ViewModel() {
    this.newNotepadName = ko.observable();
    this.notepads = ko.observableArray();
    this.notepadContent = ko.observable();
    this.notepadImage = ko.observable('/start/image/Блокноты');

    this.currentNotepad;

    var that = this;

    this.createNotepad = function () {
        model.createNotepad(this.newNotepadName());
        this.newNotepadName('');
    };

    this.openNotepad = function (notepad) {
        that.currentNotepad = notepad.notepadName;
        that.notepadImage('/start/image/' + notepad.notepadName);

        model.getNotepadContent(notepad.notepadName).success(function (content) {
            that.notepadContent(content);
        });

        model.selectNotepad(notepad.notepadName);
    };

    this.saveContent = function () {
        if (!this.currentNotepad) {
            return;
        }

        model.updateNotepad(this.currentNotepad, this.notepadContent());
    };
}