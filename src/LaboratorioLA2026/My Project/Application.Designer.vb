 'Este archivo corresponde a la configuración de aplicación de Visual Studio.
Option Strict On
Option Explicit On
Namespace My
    Partial Friend Class MyApplication
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutDownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
            Me.HighDpiMode = HighDpiMode.PerMonitorV2
        End Sub
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.LaboratorioLA2026.frmLogin
        End Sub
    End Class
End Namespace
