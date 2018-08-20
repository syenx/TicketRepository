function formataMascara(campo, evt, formato)
{
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    var result = "";
    var maskIdx = formato.length - 1;
    var error = false;
    var valor = campo.value;
    var posFinal = false;
    if (campo.setSelectionRange)
    {
        if (campo.selectionStart == valor.length) posFinal = true;
    }
    valor = valor.replace(/[^0123456789Xx]/g, '');
    for (var valIdx = valor.length - 1; valIdx >= 0 && maskIdx >= 0; --maskIdx)
    {
        var chr = valor.charAt(valIdx);
        var chrMask = formato.charAt(maskIdx);
        switch (chrMask)
        {
            case '#': if (!(/\d/.test(chr))) error = true;
                result = chr + result; --valIdx; break;
            case '@': result = chr + result; --valIdx;
                break;
            default: result = chrMask + result;
        }
    }
    campo.value = result; campo.style.color = error ? 'red' : '';
    if (posFinal) {
        campo.selectionStart = result.length;
        campo.selectionEnd = result.length;
    }
    return result;
}
function formataValor(campo, evt) { //1.000.000,00 
    var xPos = PosicaoCursor(campo); evt = getEvent(evt); var tecla = getKeyCode(evt); if (!teclaValida(tecla)) return; vr = campo.value = filtraNumeros(filtraCampo(campo)); if (vr.length > 0) { vr = parseFloat(vr.toString()).toString(); tam = vr.length; if (tam == 1) campo.value = "0,0" + vr; if (tam == 2) campo.value = "0," + vr; if ((tam > 2) && (tam <= 5)) { campo.value = vr.substr(0, tam - 2) + ',' + vr.substr(tam - 2, tam); } if ((tam >= 6) && (tam <= 8)) { campo.value = vr.substr(0, tam - 5) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam); } if ((tam >= 9) && (tam <= 11)) { campo.value = vr.substr(0, tam - 8) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam); } if ((tam >= 12) && (tam <= 14)) { campo.value = vr.substr(0, tam - 11) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam); } if ((tam >= 15) && (tam <= 18)) { campo.value = vr.substr(0, tam - 14) + '.' + vr.substr(tam - 14, 3) + '.' + vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam); } } MovimentaCursor(campo, xPos);
}

 