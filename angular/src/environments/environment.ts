import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'LonelySatan',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44370/',
    redirectUri: baseUrl,
    clientId: 'LonelySatan_App',
    responseType: 'code',
    scope: 'offline_access LonelySatan',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44370',
      rootNamespace: 'Aura.LonelySatan',
    },
  },
} as Environment;
