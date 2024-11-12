function CompanyMaskInit() {
    var cleaveCNPJ, cleaveCEP;
    document.querySelector("#cnpj") && (cleaveDelimiters = new Cleave("#cnpj", { delimiters: [".", ".", "/", "-"], blocks: [2, 3, 3, 4, 2], uppercase: !0 })),
    document.querySelector("#cep") && (cleaveDelimiters = new Cleave("#cep", { delimiters: [".", "-"], blocks: [2, 3, 3], uppercase: !0 }));
}
