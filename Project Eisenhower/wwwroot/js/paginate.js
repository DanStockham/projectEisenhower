let pagination = (function ($) {
    const publishedEvents = events.PublishedEvent;
    const draftEvents = events.DraftEvent;
    const pastEvents = events.PastEvent;

    const containers = [
        { el: $("#published"), items: publishedEvents },
        { el: $('#draft'), items: draftEvents },
        { el: $('#past'), items: pastEvents }
    ];

    function invokePagination() {
        containers.forEach(container => {
            let paginateComponent = container.el.find(".paginate-container");

            if (container.items.length !== 0) {
                paginateComponent.pagination({
                    dataSource: container.items,
                    pageSize: 5,
                    activeClassName: "active",
                    ulClassName: "pagination",
                    callback: function (data, pagination) {
                        let html = listItemTemplate(data);

                        pagination.el.find("li").addClass("page-item");
                        pagination.el.find("li").find("a").addClass("page-link");

                        container.el.find(".list-group").html(html);

                    }
                });
               
            } else {
                container.el.addClass("h-50");
                container.el.html(`
                    <div class="d-flex justify-content-center">
                        <div class="event-state">
                            <div class="text-center"><i class="fas fa-exclamation"></i></div>    
                            <p class=" text-center">Hmmm... no events to show</span>
                        </div>
                    </div>
                `);
            }
        });
    }

    function listItemTemplate(data) {
        let itemElements = data.map(function (item) {
            let date = new Intl.DateTimeFormat('en-US', { weekday: 'long', month: 'long', day: 'numeric', year: 'numeric', hour: 'numeric', minute: 'numeric' }).format(new Date(item.StartDate));
            return `
               <li class="list-group-item">
                            <a href="Event/Details/${item.EventId}">${item.OpName}</a>
                            <p>${date}</p>
                            <ul class="d-flex flex-row bd-highlight mb-3 event-actions">
                                <li class="nav-item">
                                    <a href="#">Publish</a>
                                </li>
                                <li class="nav-item">
                                    <a href="Event/Edit/${item.EventId}">Edit</a>
                                </li>
                                <li class="nav-item">
                                    <a href="Event/Details/${item.EventId}">View</a>
                                </li>
                            </ul>
                        </li>
            `;
        });

        return itemElements;
    }

    return {
        invokePagination
    };
})($, events);


console.log(pagination);
pagination.invokePagination();