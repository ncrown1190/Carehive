export interface User {
    userId: number;
    name: string;
    loginId: string;
    passwordHash?: string;
    phone?: string;
    email: string;
    role: string;
    token?: string;
  }