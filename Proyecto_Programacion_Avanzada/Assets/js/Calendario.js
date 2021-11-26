$(document).ready(function () {
    var events = [];
    var selectedEvent = null;
    FetchEventAndRenderCalendar();
    function FetchEventAndRenderCalendar() {
        events = [];
        $.ajax({
            type: "GET",
            url: "/Citas/GetEvents",
            dataType: 'json',
            success: function (data) {
                $.each(data, function (i, v) {
                    events.push({
                        eventID: v.CodigoCitas,
                        title: v.Asunto,
                        description: v.Descripcion,
                        start: moment(v.HoraInicio),
                        end: v.HoraFin != null ? moment(v.HoraFin) : null,
                        color: v.TemaColor,
                        allDay: v.esTodoElDia,
                        textColor: 'white'
                    });
                })
                GenerateCalender(events);
            },
            error: function (error) {
                alert('failed');
            }
        })
    }


    function GenerateCalender(events) {
        $('#calender').fullCalendar('destroy');
        $('#calender').fullCalendar({
            contentHeight: 400,
            defaultView: 'agendaWeek',
            defaultDate: new Date(),
            hiddenDays: [0, 6],
            themeSystem: 'bootstrap',
            timeFormat: 'h(:mm)a',
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'agendaWeek,agenda'
            },
            eventLimit: true,
            eventColor: '#378006',
            events: events,
            eventClick: function (calEvent, jsEvent, view) {
                selectedEvent = calEvent;
                $('#ModalEventos #eventTitle').text(calEvent.title);
                var $description = $('<div/>');
                $description.append($('<p/>').html('<b>Start:</b>' + calEvent.start.format("YYYY-MMM-DD HH:mm a")));
                if (calEvent.end != null) {
                    $description.append($('<p/>').html('<b>End:</b>' + calEvent.end.format("YYYY-MMM-DD HH:mm a")));
                }
                $description.append($('<p/>').html('<b>Description:</b>' + calEvent.description));
                $('#ModalEventos #pDetails').empty().html($description);

                $('#ModalEventos').modal();
            },
            selectable: true,
            select: function (start, end) {
                selectedEvent = {
                    eventID: 0,
                    title: '',
                    description: '',
                    start: start,
                    end: end,
                    allDay: false,
                    color: ''
                };
                openAddEditForm();
                $('#calendar').fullCalendar('unselect');
            }
            ,
            editable: true,
            eventDrop: function (event) {
                var data = {
                    EventID: event.eventID,
                    Subject: event.title,
                    Start: event.start.format('YYYY/MM/DD HH:mm A'),
                    End: event.end != null ? event.end.format('YYYY/MM/DD HH:mm A') : null,
                    Description: event.description,
                    ThemeColor: event.color,
                    IsFullDay: event.allDay
                };
                SaveEvent(data);
            }
        })
    }

    $('#btnEdit').click(function () {
        //Open modal dialog for edit event
        openAddEditForm();
    })
    $('#btnDelete').click(function () {
        if (selectedEvent != null && confirm('Are you sure?')) {
            $.ajax({
                type: "POST",
                url: '/Citas/DeleteEvent',
                data: {eventoID: selectedEvent.eventID},
                success: function (data) {
                    if (data.status) {
                        //Refresh the calender
                        FetchEventAndRenderCalendar();
                        $('#myModal').modal('hide');
                    }
                },
                error: function () {
                    alert('Failed');
                    FetchEventAndRenderCalendar();
                }
            })
        }
    })


    $('#dtp1,#dtp2').datetimepicker({
        format: 'YYYY/MM/DD HH:mm A'
    });

    //$('#chkIsFullDay').change(function () {
    //    if ($(this).is(':checked')) {
    //        $('#divEndDate').hide();
    //    }
    //    else {
    //        $('#divEndDate').show();
    //    }
    //});

    $('#divEndDate').show();

    function openAddEditForm() {
        if (selectedEvent != null) {
            $('#hdEventID').val(selectedEvent.eventID);
            $('#txtSubject').val(selectedEvent.title);
            $('#txtStart').val(selectedEvent.start.format('YYYY/MM/DD HH:mm A'));
            $('#chkIsFullDay').prop("checked", selectedEvent.allDay || false);
            $('#chkIsFullDay').change();
            $('#txtEnd').val(selectedEvent.end != null ? selectedEvent.end.format('YYYY/MM/DD HH:mm A') : '');
            $('#txtDescription').val(selectedEvent.description);
            $('#SelectDoctor').val(selectedEvent.color);
        }
        $('#myModal').modal('hide');
        $('#myModalSave').modal();
    }

    $('#btnSave').click(function () {
        //Validation/
        if ($('#txtSubject').val().trim() == "") {
            alert('Subject required');
            return;
        }
        if ($('#txtStart').val().trim() == "") {
            alert('Start date required');
            return;
        }
        if ($('#chkIsFullDay').is(':checked') == false && $('#txtEnd').val().trim() == "") {
            alert('End date required');
            return;
        }
        else {
            var startDate = moment($('#txtStart').val(), "YYYY/MM/DD HH:mm A").toDate();
            var endDate = moment($('#txtEnd').val(), "YYYY/MM/DD HH:mm A").toDate();
            if (startDate > endDate) {
                alert('Invalid end date');
                return;
            }
        }

        var data = {
            EventID: $('#hdEventID').val(),
            Subject: $('#txtSubject').val().trim(),
            Start: $('#txtStart').val().trim(),
            End: $('#chkIsFullDay').is(':checked') ? null : $('#txtEnd').val().trim(),
            Description: $('#txtDescription').val(),
            Doctor: $('#SelectDoctor').val(),
            IsFullDay: $('#chkIsFullDay').is(':checked')
        }
        SaveEvent(data);
        // call function for submit data to the server
    })

    function SaveEvent(data) {
        $.ajax({
            type: "POST",
            url: '/Citas/SaveEvent',
            //long codigoCitas, string asunto,string descripcion, DateTime horaInicio,DateTime horaFin,string temaColor,Boolean esTodoElDia
            data: { codigoCitas: data.EventID, asunto: data.Subject, descripcion: data.Description, horaInicio: data.Start, horaFin: data.End, esTodoElDia: data.IsFullDay, codDoctor: data.Doctor},
            dataType: 'json',
            success: function (data) {
                if (data.status) {
                    //Refresh the calender
                    FetchEventAndRenderCalendar();
                    $('#myModalSave').modal('hide');
                }
            },
            error: function () {
                alert('Failed');
                FetchEventAndRenderCalendar();
            }
        })
    }
})