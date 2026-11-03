const toggle = document.querySelector('.menu-toggle');
const menu = document.getElementById('nav-content');
const search = document.getElementById('site-search');
const status = document.getElementById('search-status');
const sections = [...document.querySelectorAll('[data-searchable]')];
toggle.addEventListener('click', () => {
  const open = toggle.getAttribute('aria-expanded') !== 'true';
  toggle.setAttribute('aria-expanded', String(open));
  toggle.setAttribute('aria-label', open ? 'Close menu' : 'Open menu');
  menu.classList.toggle('open', open);
});
menu.querySelectorAll('a').forEach(link => link.addEventListener('click', () => {
  menu.classList.remove('open');
  toggle.setAttribute('aria-expanded', 'false');
}));


document.getElementById('search-form').addEventListener('submit', event => {
  event.preventDefault();
  const query = search.value.trim().toLocaleLowerCase();
  status.textContent = '';
  if (!query) { search.focus(); return; }
  const match = sections.find(section => section.textContent.toLocaleLowerCase().includes(query));
  if (match) {
    match.scrollIntoView({behavior:'smooth',block:'start'});
    status.textContent = 'Matching section found.';
  } else {
    status.textContent = 'No matching section found.';
  }
});
