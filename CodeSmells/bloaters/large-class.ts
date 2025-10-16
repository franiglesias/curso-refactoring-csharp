// Code smell: Large Class [Clase grande].
// UserAccount acumula muchas responsabilidades no relacionadas
// como autenticación, perfil, notificaciones y gestión de administración,
// lo que dificulta el cambio.

// Ejercicio: Añade autenticación de dos factores (2FA) y preferencias de notificación.

// Tocarás autenticación, estado y notificaciones en una clase inflada,
// aumentando la probabilidad de romper comportamiento no relacionado.

class UserAccount {
  private name: string
  private email: string
  private password: string
  private lastLogin: Date
  private loginAttempts: number = 0
  private notifications: string[] = []
  private isAdmin: boolean

  constructor(name: string, email: string, password: string, isAdmin: boolean = false) {
    this.name = name
    this.email = email
    this.password = password
    this.lastLogin = new Date()
    this.isAdmin = isAdmin
  }

  // --- Autenticación ---
  login(password: string): boolean {
    if (this.password === password) {
      this.lastLogin = new Date()
      this.loginAttempts = 0
      console.log('Inicio de sesión exitoso')
      return true
    } else {
      this.loginAttempts++
      console.log('Contraseña incorrecta')
      return false
    }
  }

  resetPassword(newPassword: string): void {
    this.password = newPassword
    console.log('Contraseña actualizada')
  }

  // --- Perfil ---
  updateEmail(newEmail: string): void {
    this.email = newEmail
    console.log('Correo actualizado')
  }

  updateName(newName: string): void {
    this.name = newName
    console.log('Nombre actualizado')
  }

  // --- Notificaciones ---
  addNotification(message: string): void {
    this.notifications.push(message)
  }

  getNotifications(): string[] {
    return this.notifications
  }

  clearNotifications(): void {
    this.notifications = []
  }

  // --- Administración ---
  promoteToAdmin(): void {
    this.isAdmin = true
  }

  revokeAdmin(): void {
    this.isAdmin = false
  }
}
