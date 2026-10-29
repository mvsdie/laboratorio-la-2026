Imports Microsoft.VisualBasic.ApplicationServices
Imports System.IO

Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If e.CommandLine.Contains("--preparar-usuarios") Then
                e.Cancel = True
                MessageBox.Show("El procedimiento anterior fue reemplazado. Usá --preparar-tres-usuarios.")
                Exit Sub
            End If
            If e.CommandLine.Contains("--preparar-tres-usuarios") Then
                e.Cancel = True
                Using formulario As New frmUsuarios()
                    formulario.PreparacionInicial = True
                    Try
                        If formulario.ShowDialog() = DialogResult.OK Then
                            Dim informe As String = formulario.VerificarPreparacionInicial()
                            Dim ruta As String = Path.Combine(AppContext.BaseDirectory, "RESULTADO_TRES_USUARIOS.txt")
                            Try
                                File.WriteAllText(ruta, informe)
                                MessageBox.Show(informe & Environment.NewLine & "Informe local: RESULTADO_TRES_USUARIOS.txt")
                            Catch ex As Exception
                                MessageBox.Show(informe & Environment.NewLine & "No se pudo guardar el informe local.")
                            End Try
                        End If
                    Finally
                        formulario.LimpiarPreparacion()
                        Sesion.CerrarSesion()
                    End Try
                End Using
            End If
        End Sub
    End Class
End Namespace
