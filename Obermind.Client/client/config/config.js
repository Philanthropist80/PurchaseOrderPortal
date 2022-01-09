export const API_PATH = 'api/v1';

export const APP_HOST = process.env.APP_HOST || 'localhost';
export const APP_PORT = process.env.APP_PORT || 5001;
export const HOST = `${APP_HOST}:${APP_PORT}`;

export const API_URL = `https://${HOST}/${API_PATH}`;
export const JWT_TOKEN = 'token';
export const USER_NAME = 'username';
export const USER_EMAIL = 'email';
export const USER_FIRST_NAME = 'firstname';
export const USER_LAST_NAME = 'lastname';