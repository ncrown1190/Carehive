export interface CreateUser {
    userId: number;
    UserName: string;
    loginId: string;
    passwordHash?: string;
    phone?: string;
    email: string;
    role: string;
    address: string;
    token?: string;
  }