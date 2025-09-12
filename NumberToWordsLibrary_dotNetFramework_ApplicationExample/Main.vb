Imports NandoStyle.NumberToWordConverter.NumberToWordConverter

Public Class Main
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Dim myCurrencyToUse As CurrencyToUse
        Dim selectedCurrencyItem As String = cmbCurrency.Text

        If String.IsNullOrEmpty(selectedCurrencyItem) Then
            Return
        End If

        If selectedCurrencyItem = "Dollars" Then
            myCurrencyToUse = CurrencyToUse.Dollar
        ElseIf selectedCurrencyItem = "Pesos" Then
            myCurrencyToUse = CurrencyToUse.Peso
        End If

        Dim selectedLanguage As LanguageToUse
        Dim selectedLanguageItem As String = cmbLanguage.Text

        If String.IsNullOrEmpty(selectedLanguageItem) Then
            Return
        End If

        If selectedLanguageItem = "English" Then
            selectedLanguage = LanguageToUse.English
        ElseIf selectedLanguageItem = "Spanish" Then
            selectedLanguage = LanguageToUse.Spanish
        End If

        Dim DecimalNumber As Decimal
        If Decimal.TryParse(txtNumberToConvert.Text, DecimalNumber) Then
            lblResults.Text = ToWords(DecimalNumber, selectedLanguage, myCurrencyToUse)
        Else
            lblResults.Text = "Invalid number format."
        End If
    End Sub

    Private Sub btnAutomatedTest_Click(sender As Object, e As EventArgs) Handles btnAutomatedTest.Click
        txtAllResults.Text = NumberTowordsAutomatedTester()
    End Sub

End Class
