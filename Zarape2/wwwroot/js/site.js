(function () {
    const STORAGE_KEY = 'zarape2-sidebar-collapsed';
    const wrapper = document.getElementById('appWrapper');
    const sidebar = document.getElementById('sidebar');
    const overlay = document.getElementById('sidebarOverlay');
    const openBtn = document.getElementById('sidebarOpenBtn');
    const closeBtn = document.getElementById('sidebarClose');
    const collapseBtn = document.getElementById('sidebarCollapseBtn');

    if (!wrapper || !sidebar) return;

    const isDesktop = () => window.matchMedia('(min-width: 992px)').matches;

    function openSidebar() {
        if (isDesktop()) {
            wrapper.classList.remove('sidebar-hidden');
        } else {
            sidebar.classList.add('open');
            overlay.classList.add('show');
            overlay.setAttribute('aria-hidden', 'false');
        }
    }

    function closeSidebar() {
        if (isDesktop()) {
            wrapper.classList.add('sidebar-hidden');
        } else {
            sidebar.classList.remove('open');
            overlay.classList.remove('show');
            overlay.setAttribute('aria-hidden', 'true');
        }
    }

    function toggleCollapse() {
        const collapsed = wrapper.classList.toggle('sidebar-collapsed');
        localStorage.setItem(STORAGE_KEY, collapsed ? '1' : '0');
    }

    function initDesktopState() {
        if (!isDesktop()) {
            wrapper.classList.remove('sidebar-collapsed', 'sidebar-hidden');
            return;
        }

        sidebar.classList.remove('open');
        overlay.classList.remove('show');

        if (localStorage.getItem(STORAGE_KEY) === '1') {
            wrapper.classList.add('sidebar-collapsed');
        }
    }

    openBtn?.addEventListener('click', openSidebar);
    closeBtn?.addEventListener('click', closeSidebar);
    overlay?.addEventListener('click', closeSidebar);
    collapseBtn?.addEventListener('click', toggleCollapse);

    sidebar.querySelectorAll('.sidebar-link').forEach(link => {
        link.addEventListener('click', () => {
            if (!isDesktop()) closeSidebar();
        });
    });

    window.addEventListener('resize', initDesktopState);
    initDesktopState();
})();
