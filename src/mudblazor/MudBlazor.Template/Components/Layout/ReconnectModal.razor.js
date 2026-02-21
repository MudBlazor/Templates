const modal = document.getElementById('components-reconnect-modal');
const reconnectButton = document.getElementById('components-reconnect-button');
const resumeButton = document.getElementById('components-resume-button');
const secondsToNextAttempt = document.getElementById('components-seconds-to-next-attempt');

reconnectButton?.addEventListener('click', () => Blazor.reconnect());
resumeButton?.addEventListener('click', () => Blazor.resume());

Blazor.registerCustomEventType?.('reconnect', {});

window.Blazor.start({
    circuit: {
        reconnectionHandler: {
            onConnectionDown(options, _error) {
                modal?.removeAttribute('class');
                if (!modal?.hasAttribute('open')) {
                    modal?.showModal();
                }

                if (options.nextRetryIntervalMilliseconds !== undefined) {
                    let secondsRemaining = Math.round(options.nextRetryIntervalMilliseconds / 1000);
                    if (secondsToNextAttempt) {
                        secondsToNextAttempt.innerText = secondsRemaining;
                    }

                    const timer = setInterval(() => {
                        secondsRemaining--;
                        if (secondsToNextAttempt) {
                            secondsToNextAttempt.innerText = secondsRemaining;
                        }
                        if (secondsRemaining <= 0) {
                            clearInterval(timer);
                        }
                    }, 1000);

                    modal?.setAttribute('class', 'components-reconnect-repeated-attempt');
                } else {
                    modal?.setAttribute('class', 'components-reconnect-show');
                }
            },
            onConnectionUp() {
                modal?.removeAttribute('class');
                modal?.close();
            },
            onMaximumRetryCountExceeded(_error) {
                modal?.removeAttribute('class');
                modal?.setAttribute('class', 'components-reconnect-failed');
            },
        },
    },
});
