function setDemo(value){const input=document.querySelector('input[name="Url"]');if(input){input.value=value;input.focus();document.querySelector('#scanner')?.scrollIntoView({behavior:'smooth',block:'center'});}}
// Tiny progressive enhancement: reveal a friendly confirmation when the scanner form submits.
document.querySelectorAll('form.scan-form').forEach(form=>form.addEventListener('submit',()=>{const button=form.querySelector('button[type="submit"]');if(button){button.disabled=true;button.innerHTML='Checking link… <span>↗</span>';}}));
