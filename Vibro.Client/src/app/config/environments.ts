const API_URLS = {
  dev: 'https://localhost:5000',
  prod: 'https://api.vibro.com'
};

export const apiUrl: string =
  window.location.hostname.includes('localhost')
  ? API_URLS.dev : API_URLS.prod
